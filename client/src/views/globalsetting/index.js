import * as yup from 'yup'
import { Card, CardHeader, CardTitle, CardBody, Button, FormGroup, Label, Input, FormFeedback, Row, Col, CustomInput, InputGroup, InputGroupAddon, InputGroupText } from 'reactstrap'
import { Formik, Form } from "formik"
import { useState, useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { getRecord, updateRecord } from './store/action'
import DualListBox from 'react-dual-listbox'
import '@fortawesome/fontawesome-free/css/all.css'
import 'react-dual-listbox/lib/react-dual-listbox.css'
import DtmfsSelect from './DtmfsSelect'
import PrivilgeSelect from './PrivilgeSelect'
import JitterBuffersSelect from './JitterBuffersSelect'
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min'


const SettingForm = () => {

    const dispatch = useDispatch()
    const history = useHistory()
    const record = useSelector(state => state.GlobalSettingStore)

    // console.log(record)

    const [setting, setSetting] = useState({
        Id: record.data.id,
        Ext_DTMF: record.data.ext_DTMF,
        Ext_Ring_Time: record.data.ext_Ring_Time,
        Ext_CC_Registrations: record.data.ext_CC_Registrations,
        Ext_Privilege: record.data.ext_Privilege,
        JitterBuffer: record.data.jitterBuffer,
        Enable_VM: record.data.enable_VM,
        Sync_Contact: record.data.sync_Contact,
        Enable_NAT: record.data.enable_NAT,
        CodecTo: record.data.codecTo,
        CodecFrom: record.data.codecFrom
    })

    useEffect(() => {
        if (record.data) {
            setSetting({
                Id: record.data.id,
                Ext_DTMF: record.data.ext_DTMF,
                Ext_Ring_Time: record.data.ext_Ring_Time,
                Ext_CC_Registrations: record.data.ext_CC_Registrations,
                Ext_Privilege: record.data.ext_Privilege,
                JitterBuffer: record.data.jitterBuffer,
                Enable_VM: record.data.enable_VM,
                Sync_Contact: record.data.sync_Contact,
                Enable_NAT: record.data.enable_NAT,
                CodecTo: record.data.codecTo,
                CodecFrom: record.data.codecFrom
            })
        }
    }, [record])


    // console.log(setting)

    const codecoptions = record.data.codecFrom || []
    const options = codecoptions.map((e) => {
        return { value: e, label: e }
    })


    const Settingschema = yup.object().shape({
        Ext_CC_Registrations: yup.number().typeError("Must be number")
            .required("Extension Concurrent Registrations is Requierd")
            .integer("Must be between 1 and 5")
            .min(1, "Must be between 1 and 5")
            .max(5, "Must be between 1 and 5"),
        CodecTo: yup.array()
            .of(yup.string())
            .min(1, "Must select at least one codec")
            .required("Must select at least one codec")

    })


    const handleSubmit = (values) => {
        // console.log(values)
        dispatch(updateRecord(setting))
    }

    const handleData = (e) => {
        setSetting({ ...setting, [e.target.name]: e.target.value })
    }
    const handleCheckbox = (e) => {
        setSetting({ ...setting, [e.target.name]: e.target.checked })
    }

    const handleCanel = () => {
        history.push("/")
    }

    return (

        <>
            < Formik
                validationSchema={Settingschema}
                initialValues={setting}
                enableReinitialize={true}
                onSubmit={(values) => {
                    handleSubmit(values)
                    // resetForm()
                }}
                validateOnBlur={true}
                validateOnChange={true}
            >
                {({ errors, touched, isValid }) => {

                    return (
                        <Card>
                            <CardHeader>
                                <CardTitle tag='h4'>Default Setting</CardTitle>
                            </CardHeader>
                            <CardBody>
                                <Form>
                                    <Row>
                                        <Col md='4' sm='12'>
                                            <CustomInput inline type='checkbox'
                                                name="Enable_VM"
                                                id='exampleCustomCheckbox1'
                                                onChange={handleCheckbox}
                                                label='Enable VM'
                                                defaultChecked={setting.Enable_VM}
                                            />
                                        </Col>

                                        <Col md='4' sm='12'>
                                            <CustomInput inline type='checkbox'
                                                id='exampleCustomCheckbox2'
                                                name="Enable_NAT"
                                                label='Enable NAT'
                                                onChange={handleCheckbox}
                                                defaultChecked={setting.Enable_NAT}
                                            />
                                        </Col>

                                        <Col md='4' sm='12'>
                                            <CustomInput inline type='checkbox'
                                                id='exampleCustomCheckbox3'
                                                name="Sync_Contact"
                                                label='Sync Contact'
                                                onChange={handleCheckbox}
                                                defaultChecked={setting.Sync_Contact}
                                            />
                                        </Col>

                                        <Col md='3' sm='12' className='mt-1'>
                                            <Label>DTMF</Label>
                                            <DtmfsSelect name='Ext_DTMF' value={setting.Ext_DTMF} handleOnChange={handleData} />

                                        </Col>
                                        <Col md='3' sm='12' className='mt-1'>
                                            <Label>Extension Privilge</Label>
                                            <PrivilgeSelect name='Ext_Privilege' value={setting.Ext_Privilege} handleOnChange={handleData} />
                                        </Col>
                                        <Col md='3' sm='12' className='mt-1'>
                                            <Label>Jitter Buffer</Label>
                                            <JitterBuffersSelect name='JitterBuffer' value={setting.JitterBuffer} handleOnChange={handleData} />
                                        </Col>

                                        <Col md='3' sm='12' className='mt-1'>
                                            <FormGroup>
                                                <Label for='Ext_Ring_Time'>Extension Ring Time</Label>
                                                <Input type='text'
                                                    name='Ext_Ring_Time'
                                                    id='Ext_Ring_Time'
                                                    value={setting.Ext_Ring_Time}
                                                    invalid={errors.Ext_Ring_Time && true}
                                                    placeholder='Extension Ring Time'
                                                    onChange={handleData}
                                                />
                                                {errors && errors.Ext_Ring_Time && <FormFeedback>{errors.Ext_Ring_Time}</FormFeedback>}
                                            </FormGroup>
                                        </Col>

                                        <Col md='3' sm='12' className='mt-1'>
                                            <FormGroup>
                                                <Label for='Ext_CC_Registrations'><span className="text-danger">*</span> Extension Concurrent Registrations</Label>
                                                <Input type='text'
                                                    name='Ext_CC_Registrations'
                                                    id='Ext_CC_Registrations'
                                                    value={setting.Ext_CC_Registrations}
                                                    invalid={errors.Ext_CC_Registrations && touched.Ext_CC_Registrations}
                                                    placeholder='Extension Concurrent Registrations'
                                                    onChange={handleData}
                                                />
                                                {errors.Ext_CC_Registrations && touched.Ext_CC_Registrations && (
                                                    <FormFeedback>{errors.Ext_CC_Registrations}</FormFeedback>
                                                )}

                                            </FormGroup>
                                        </Col>
                                        <Col md='9' sm='12' className='mt-1'>
                                            <Label for='codec'>Codec</Label>
                                            <DualListBox
                                                id="preserve-order"
                                                options={options}
                                                preserveSelectOrder
                                                selected={setting.CodecTo ? setting.CodecTo : []}
                                                showOrderButtons
                                                onChange={(newValue) => setSetting(prevSetting => ({
                                                    ...prevSetting,
                                                    CodecTo: newValue
                                                }))}
                                            />
                                            <span className="text-danger">{errors.CodecTo}</span>
                                        </Col>
                                        <Col md='4' sm='12' className=''>
                                            <FormGroup className='d-flex mt-2'>
                                                <Button.Ripple className='mr-1' color='primary' type='submit'>
                                                    Save
                                                </Button.Ripple>
                                                <Button.Ripple outline color='secondary' onClick={handleCanel}>
                                                    Cancel
                                                </Button.Ripple>
                                            </FormGroup>
                                        </Col>
                                    </Row>
                                </Form>

                            </CardBody>
                        </Card>
                    )
                }
                }
            </Formik>
        </>
    )
}
export default SettingForm

