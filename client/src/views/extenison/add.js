import { Fragment, useEffect, useState } from 'react'
import * as yup from 'yup'
import {
    Card, CardHeader, CardTitle,
    TabPane, Nav, NavItem, NavLink, CardBody, Button,
    FormGroup, Label, Input, FormFeedback, Row, Col,
    CustomInput, TabContent, InputGroupAddon, InputGroupText
} from 'reactstrap'

import { Formik, Form } from "formik"
import DualListBox from 'react-dual-listbox'
import '@fortawesome/fontawesome-free/css/all.css'
import 'react-dual-listbox/lib/react-dual-listbox.css'

import { Settings, Circle, Star, Watch } from 'react-feather'
import DtmfsSelect from '../globalsetting/DtmfsSelect'
import JitterBuffersSelect from '../globalsetting/JitterBuffersSelect'
import PrivilgeSelect from '../globalsetting/PrivilgeSelect'
import { useDispatch, useSelector } from 'react-redux'
import generateRandomPassword from './generateRandomPassword'
import { createExt, getExt, setLoading, updateExt } from './store'
import { useHistory, useLocation, useParams } from 'react-router-dom/cjs/react-router-dom.min'


const ExtensionForm = () => {

    const record = useSelector(state => state.GlobalSettingStore)
    // console.log(record)

    //select Extension
    const Extstore = useSelector(state => state.ExtStore)
    const selectedExtenison = Extstore.selectedItem
    const ExtNumber = localStorage.getItem("LastExtNumber")

    // let idAsNumber
    const { id } = useParams()
    const idAsNumber = parseInt(id, 10)
    // console.log(idAsNumber)

    const sipPasswordValue = generateRandomPassword(8)
    const ExtUserPasswordValue = generateRandomPassword(6)

    // console.log(sipPasswordValue)
    const dispatch = useDispatch()
    const history = useHistory()
    const [active, setActive] = useState('1')
    const [extstate, setExtState] = useState({
        Enable_Ext: true,
        Ext_Number: parseInt(ExtNumber, 10),
        CallerId_Number: '',
        Call_PrivilegeId: record.data.ext_Privilege,
        SIP_Password: sipPasswordValue,
        AuthId: '',
        Enable_NAT: record.data.enable_NAT,
        Enable_DM: false,
        DTMF_ModeId: record.data.ext_DTMF,
        JitterBufferId: record.data.jitterBuffer,
        A_CodecFrom: record.data.codecFrom,
        A_CodecTo: record.data.codecTo,
        SRTP: 1,
        Enable_VM: record.data.enable_VM,
        VM_Password: 1234,
        Enable_KA: false,
        KA_Freq: 60,
        Sync_Contact: record.data.sync_Contact,
        F_Name: '',
        L_Name: '',
        Mobile: '',
        Email: '',
        Ext_User_pswd: ExtUserPasswordValue,
        Ext_CC_Registrations: record.data.ext_CC_Registrations,
        DepartmentId: 1,
        Job_Title: '',
        Extension_Ring_Time: record.data.ext_Ring_Time,
        Language: 1,
        Call_Forward_AlwaysId: '',
        Call_Forward_No_AnswerId: '',
        Call_Forworad_BusyId: '',
        CFU_Time_CondtionId: '',
        CFN_Time_CondtionId: '',
        CFB_Time_CondtionId: '',
        DND_Time_CondtionId: '',
        DND_WhiteList: '',
        Do_Not_Disturb: ''
    })

    useEffect(() => {
        if (id) {
            console.log("effect-1")
            dispatch(getExt(idAsNumber))
        }
    }, [id])

    useEffect(() => {
        if (id) {
            console.log("effect=3")
            setExtState({
                Enable_Ext: selectedExtenison.enable_Ext,
                Ext_Number: selectedExtenison.ext_Number,
                CallerId_Number: selectedExtenison.CallerId_Number,
                Call_PrivilegeId: selectedExtenison.call_PrivilegeId,
                SIP_Password: selectedExtenison.siP_Password,
                AuthId: selectedExtenison.authId,
                Enable_NAT: selectedExtenison.enable_NAT,
                Enable_DM: selectedExtenison.enable_DM,
                DTMF_ModeId: selectedExtenison.dTMF_ModeId,
                JitterBufferId: selectedExtenison.jitterBufferId,
                A_CodecFrom: selectedExtenison.a_CodecFrom,
                A_CodecTo: selectedExtenison.a_CodecTo,
                SRTP: selectedExtenison.srtp,
                Enable_VM: selectedExtenison.enable_VM,
                VM_Password: selectedExtenison.vM_Password,
                Enable_KA: selectedExtenison.enable_KA,
                KA_Freq: selectedExtenison.kA_Freq,
                Sync_Contact: selectedExtenison.sync_Contact,
                F_Name: selectedExtenison.f_Name,
                L_Name: selectedExtenison.l_Name,
                Mobile: selectedExtenison.mobile,
                Email: selectedExtenison.email,
                Ext_User_pswd: selectedExtenison.ext_User_pswd,
                Ext_CC_Registrations: selectedExtenison.ext_CC_Registrations,
                DepartmentId: selectedExtenison.departmentId,
                Job_Title: selectedExtenison.job_Title,
                Extension_Ring_Time: selectedExtenison.extension_Ring_Time,
                Language: selectedExtenison.language,
                Call_Forward_AlwaysId: selectedExtenison.call_Forward_AlwaysId,
                Call_Forward_No_AnswerId: selectedExtenison.call_Forward_No_AnswerId,
                Call_Forworad_BusyId: selectedExtenison.call_Forworad_BusyId,
                CFU_Time_CondtionId: selectedExtenison.cfU_Time_CondtionId,
                CFN_Time_CondtionId: selectedExtenison.cfN_Time_CondtionId,
                CFB_Time_CondtionId: selectedExtenison.cfB_Time_CondtionId,
                DND_Time_CondtionId: selectedExtenison.dnD_Time_Condtion,
                DND_WhiteList: selectedExtenison.dnD_WhiteList,
                Do_Not_Disturb: selectedExtenison.do_Not_Disturb
            })
        }
    }, [selectedExtenison])

    // console.log(extstate)

    const codecoptions = record.data.codecFrom || []
    const options = codecoptions.map((e) => {
        return { value: e, label: e }
    })
    const strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")

    const Extschema = yup.object().shape({
        Ext_Number: yup.number().typeError("Must be number").required("Extension number is requierd"),
        CallerId_Number: yup.number().typeError("Must be number"),
        SIP_Password: yup.string().required("SIP Password is requierd")
            .min(8, "SIP Password must be 8 digits")
            .test("is-complex", "SIP Password must meet complexity requirements",
                (value) => strongRegex.test(value)
            ),

        KA_Freq: yup.number().typeError("KA Freq Must be a number")
            .when("Enable_KA", {
                is: true,
                then: yup.number().required("KA Freq is required when fk is checked")
            }),

        Ext_User_pswd: yup.string().required("Ext User Password is requierd").min(6, "Must be 6 digits"),

        Extension_Ring_Time: yup.number().typeError("Must be number"),

        Ext_CC_Registrations: yup.number().typeError("Must be number")
            .required("Extension Concurrent Registrations is Requierd")
            .integer("Must be between 1 and 5")
            .min(1, "Must be between 1 and 5")
            .max(5, "Must be between 1 and 5"),
        A_CodecTo: yup.array()
            .of(yup.string())
            .min(1, "Must select at least one codec")
            .required("Must select at least one codec")

    })

    const toggle = tab => {
        if (active !== tab) {
            setActive(tab)
        }
    }

    const handleData = (e) => {
        setExtState({ ...extstate, [e.target.name]: e.target.value })
    }
    const handleCheckbox = (e) => {
        setExtState({ ...extstate, [e.target.name]: e.target.checked })
    }

    const handleCancel = () => {
        history.push("/extenison")
    }

    //asyn/await is very imbortant to await createExt fire and then navigate
    const handleSubmit = async (values) => {
        if (idAsNumber) {
            await dispatch(updateExt(idAsNumber, { ...extstate, Id: idAsNumber }))
        } else {
            await dispatch(createExt(extstate))
        }
        history.push("/extenison")
    }

    return (
        <>
            <Formik
                validationSchema={Extschema}
                initialValues={extstate}
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
                        <>
                            <Card>
                                <CardHeader>
                                    <CardTitle tag='h4'>New Extenion
                                    </CardTitle>
                                </CardHeader>
                                <CardBody>
                                    <Form>
                                        <Nav tabs>
                                            <NavItem>
                                                <NavLink
                                                    active={active === '1'}
                                                    onClick={() => {
                                                        toggle('1')
                                                    }}
                                                >
                                                    <Settings size={14} />
                                                    <span className='align-middle'>Basic</span>
                                                </NavLink>
                                            </NavItem>
                                            <NavItem>
                                                <NavLink
                                                    active={active === '2'}
                                                    onClick={() => {
                                                        toggle('2')
                                                    }}
                                                >
                                                    <Circle size={14} />
                                                    <span className='align-middle'>Media</span>
                                                </NavLink>
                                            </NavItem>
                                            <NavItem>
                                                <NavLink
                                                    active={active === '4'}
                                                    onClick={() => {
                                                        toggle('4')
                                                    }}
                                                >
                                                    <Star size={14} />
                                                    <span className='align-middle'>Features</span>
                                                </NavLink>
                                            </NavItem>
                                            <NavItem>
                                                <NavLink
                                                    active={active === '3'}
                                                    onClick={() => {
                                                        toggle('3')
                                                    }}
                                                >
                                                    <Watch size={14} />
                                                    <span className='align-middle'>Follow Me</span>
                                                </NavLink>
                                            </NavItem>
                                        </Nav>
                                        <hr />
                                        <TabContent className='py-50' activeTab={active}>
                                            <TabPane tabId='1'>
                                                <div className='panal-title'>
                                                    <span className="text-primary font-wegiht-bolder">| </span>
                                                    General
                                                </div>
                                                <br />
                                                <Row>
                                                    <Col md='3' sm='12'>
                                                        <CustomInput inline="true" type='checkbox'
                                                            name="Enable_Ext"
                                                            id='exampleCustomCheckbox1'
                                                            onChange={handleCheckbox}
                                                            label='Enable This Extension'
                                                            checked={extstate.Enable_Ext}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Extension</Label>
                                                        <Input type='number'
                                                            name='Ext_Number'
                                                            id='Ext_Number'
                                                            value={extstate.Ext_Number}
                                                            readOnly={id}
                                                            invalid={errors.Ext_Number && touched.Ext_Number}
                                                            placeholder='Extension'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Ext_Number && touched.Ext_Number && (
                                                            <FormFeedback>{errors.Ext_Number}</FormFeedback>
                                                        )}
                                                    </Col>
                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>CallerID Number</Label>
                                                        <Input type='text'
                                                            name='CallerId_Number'
                                                            id='CallerId_Number'
                                                            value={extstate.CallerId_Number}
                                                            invalid={errors.CallerId_Number && touched.CallerId_Number}
                                                            placeholder='CallerId Number'
                                                            onChange={handleData}
                                                        />
                                                        {errors.CallerId_Number && touched.CallerId_Number && (
                                                            <FormFeedback>{errors.CallerId_Number}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Extension Privilge</Label>

                                                        <PrivilgeSelect name='Call_PrivilegeId' value={extstate.Call_PrivilegeId} handleOnChange={handleData} />
                                                    </Col>

                                                    <Col md='3' sm='12'>
                                                        <CustomInput inline="true" type='checkbox'
                                                            name="Enable_VM"
                                                            id='exampleCustomCheckbox2'
                                                            onChange={handleCheckbox}
                                                            label='Enable Voicemail'
                                                            checked={extstate.Enable_VM}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Voicemail Password</Label>
                                                        <Input type='text'
                                                            name='VM_Password'
                                                            id='VM_Password'
                                                            readOnly={!extstate.Enable_VM}
                                                            value={extstate.VM_Password}
                                                            placeholder='Voicemail Password'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>AuthID</Label>
                                                        <Input type='text'
                                                            name='AuthId'
                                                            id='AuthId'
                                                            value={extstate.AuthId}
                                                            placeholder='AuthID'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> SIP Password</Label>
                                                        <Input type='text'
                                                            name='SIP_Password'
                                                            id='SIP_Password'
                                                            value={extstate.SIP_Password}
                                                            invalid={errors.SIP_Password && touched.SIP_Password}
                                                            placeholder='SIP Password'
                                                            onChange={handleData}
                                                        />
                                                        {errors.SIP_Password && touched.SIP_Password && (
                                                            <FormFeedback>{errors.SIP_Password}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12'>
                                                        <CustomInput inline="true" type='checkbox'
                                                            name="Enable_KA"
                                                            id='exampleCustomCheckbox3'
                                                            onChange={handleCheckbox}
                                                            label='Enable Keep-alive'
                                                            checked={extstate.Enable_KA}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Keep-alive Frequency</Label>
                                                        <Input
                                                            type='text'
                                                            name='KA_Freq'
                                                            id='KA_Freq'
                                                            readOnly={!extstate.Enable_KA}
                                                            value={extstate.Enable_KA ? extstate.KA_Freq : 60}
                                                            invalid={errors.KA_Freq && touched.KA_Freq}
                                                            placeholder='Keep-alive Frequency'
                                                            onChange={handleData}
                                                        />
                                                        {errors.KA_Freq && touched.KA_Freq && (
                                                            <FormFeedback>{errors.KA_Freq}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Concurrent Registrations</Label>
                                                        <Input type='number'
                                                            name='Ext_CC_Registrations'
                                                            id='Ext_CC_Registrations'
                                                            value={extstate.Ext_CC_Registrations}
                                                            invalid={errors.Ext_CC_Registrations && touched.Ext_CC_Registrations}
                                                            placeholder='Concurrent Registrations'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Ext_CC_Registrations && touched.Ext_CC_Registrations && (
                                                            <FormFeedback>{errors.Ext_CC_Registrations}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Extension Ring Time</Label>
                                                        <Input type='text'
                                                            name='Extension_Ring_Time'
                                                            id='Extension_Ring_Time'
                                                            value={extstate.Extension_Ring_Time}
                                                            invalid={errors.Extension_Ring_Time && touched.Extension_Ring_Time}
                                                            placeholder='Extension Ring Time'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Extension_Ring_Time && touched.Extension_Ring_Time && (
                                                            <FormFeedback>{errors.Extension_Ring_Time}</FormFeedback>
                                                        )}
                                                    </Col>
                                                </Row>

                                                <div className='panal-title'>
                                                    <span className="text-primary font-wegiht-bolder">| </span>
                                                    User Setting
                                                </div>
                                                <br />
                                                <Row>
                                                    <Col md='3' sm='12'>
                                                        <CustomInput inline="true" type='checkbox'
                                                            name="Sync_Contact"
                                                            id='exampleCustomCheckbox4'
                                                            onChange={handleCheckbox}
                                                            label='Sync Contact'
                                                            checked={extstate.Sync_Contact}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>First Name</Label>
                                                        <Input type='text'
                                                            name='F_Name'
                                                            id='F_Name'
                                                            value={extstate.F_Name}
                                                            placeholder='First Name'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Last Name</Label>
                                                        <Input type='text'
                                                            name='L_Name'
                                                            id='L_Name'
                                                            value={extstate.L_Name}
                                                            placeholder='Last Name'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Email Address</Label>
                                                        <Input type='text'
                                                            name='Email'
                                                            id='Email'
                                                            value={extstate.Email}
                                                            placeholder='Email Address'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Mobile Number</Label>
                                                        <Input type='text'
                                                            name='Mobile'
                                                            id='Mobile'
                                                            value={extstate.Mobile}
                                                            placeholder='Mobile Number'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> User Ext Password</Label>
                                                        <Input type='text'
                                                            name='Ext_User_pswd'
                                                            id='Ext_User_pswd'
                                                            value={extstate.Ext_User_pswd}
                                                            invalid={errors.Ext_User_pswd && touched.Ext_User_pswd}
                                                            placeholder='User Ext Password'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Ext_User_pswd && touched.Ext_User_pswd && (
                                                            <FormFeedback>{errors.Ext_User_pswd}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Job Title</Label>
                                                        <Input type='text'
                                                            name='Job_Title'
                                                            id='Job_Title'
                                                            value={extstate.Job_Title}
                                                            placeholder='Job Title'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Department</Label>
                                                        <Input type='select' name='DepartmentId' value={extstate.DepartmentId} onChange={handleData} id='select-basic'>
                                                            {/* {privileges.map((e) => (
                                    <option key={e.id} value={e.id}>{e.privilege_Name}</option>
                                ))} */}
                                                        </Input>
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Language</Label>
                                                        <Input type='select' name='Language' value={extstate.Language} onChange={handleData} id='select-basic'>
                                                            <option value="1">En</option>
                                                            <option value="2">Ar</option>
                                                        </Input>
                                                    </Col>
                                                </Row>
                                            </TabPane>
                                            <TabPane tabId='2'>
                                                <div className='panal-title'>
                                                    <span className="text-primary font-wegiht-bolder">|</span>
                                                    General
                                                </div>
                                                <br />
                                                <Row>
                                                    <Col md='3' inline="true" sm='12'>
                                                        <CustomInput type='checkbox'
                                                            name="Enable_NAT"
                                                            id='exampleCustomCheckbox5'
                                                            onChange={handleCheckbox}
                                                            label='NAT'
                                                            checked={extstate.Enable_NAT}
                                                        />
                                                    </Col>
                                                    <Col md='3' inline="true" sm='12'>
                                                        <CustomInput type='checkbox'
                                                            name="Enable_DM"
                                                            id='exampleCustomCheckbox6'
                                                            onChange={handleCheckbox}
                                                            label='Enable Direct Media'
                                                            checked={extstate.Enable_DM}
                                                        />
                                                    </Col>
                                                </Row>
                                                <Row>
                                                    <Col md='3' sm='12' className='mt-1'>
                                                        <Label>DTMF Mode</Label>
                                                        <DtmfsSelect name='DTMF_ModeId' value={extstate.DTMF_ModeId} handleOnChange={handleData} />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mt-1'>
                                                        <Label>Jitter Buffer</Label>
                                                        <JitterBuffersSelect name='JitterBufferId' value={extstate.JitterBufferId} handleOnChange={handleData} />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mt-1'>
                                                        <Label>SRTP</Label>
                                                        <Input type='select' name='SRTP' value={extstate.SRTP} onChange={handleData} id='select-basic'>
                                                            <option value="1">Disabled</option>
                                                            <option value="2">Enable</option>
                                                            <option value="3">Optional</option>
                                                            <option value="4">Force</option>
                                                        </Input>
                                                    </Col>
                                                </Row>
                                                <Row>
                                                    <Col md='9' sm='12' className='mt-1'>
                                                        <Label for='codec'>Codec</Label>
                                                        <DualListBox
                                                            id="preserve-order"
                                                            options={options}
                                                            preserveSelectOrder
                                                            selected={extstate.A_CodecTo ? extstate.A_CodecTo : []}
                                                            showOrderButtons
                                                            onChange={(newValue) => setExtState(prevSetting => ({
                                                                ...prevSetting,
                                                                A_CodecTo: newValue
                                                            }))}
                                                        />
                                                        <span className="text-danger">{errors.A_CodecTo}</span>
                                                    </Col>
                                                </Row>
                                            </TabPane>
                                            <TabPane tabId='3'>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                            </TabPane>

                                            <TabPane tabId='4'>
                                                <p>
                                                </p>
                                                <p>
                                                </p>
                                            </TabPane>

                                            <Col md='4' sm='12' className=''>
                                                <FormGroup className='d-flex mt-2'>
                                                    <Button.Ripple className='mr-1' color={idAsNumber ? 'warning' : 'primary'} type='submit'>
                                                        {idAsNumber ? 'Update' : 'Save'}
                                                    </Button.Ripple>
                                                    <Button.Ripple outline color='secondary' onClick={handleCancel}>
                                                        Cancel
                                                    </Button.Ripple>
                                                </FormGroup>
                                            </Col>
                                        </TabContent>
                                    </Form>

                                </CardBody>
                            </Card>
                        </>
                    )
                }}
            </Formik>
        </>

    )
}
export default ExtensionForm
