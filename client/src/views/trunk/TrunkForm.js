import { Form, Formik } from 'formik'
import React, { useState } from 'react'
import { Circle, Settings } from 'react-feather'
import { useSelector } from 'react-redux'
import {
    Card, CardHeader, CardTitle,
    TabPane, Nav, NavItem, NavLink, CardBody, Button,
    FormGroup, Label, Input, FormFeedback, Row, Col,
    CustomInput, TabContent
} from 'reactstrap'
import DtmfsSelect from '../globalsetting/DtmfsSelect'
import '@fortawesome/fontawesome-free/css/all.css'
import DualListBox from 'react-dual-listbox'
import 'react-dual-listbox/lib/react-dual-listbox.css'
import * as yup from 'yup'
import { useHistory, useParams } from 'react-router-dom/cjs/react-router-dom.min'
import { createTrunk } from './store'

const TrunkForm = () => {

    const { id } = useParams()
    const idAsNumber = parseInt(id, 10)

    const record = useSelector(state => state.GlobalSettingStore)
    const history = useHistory()
    const [active, setActive] = useState('1')

    const [trunkstate, setTrunkstate] = useState({
        Enable_Trunk: true,
        Enable_KA: false,
        Enable_NAT: record.data.enable_NAT,
        Name: "",
        From_User: "",
        From_Domain: "",
        DTMF_ModeId: "",
        SRTP: 1,
        A_CodecFrom: record.data.codecFrom,
        A_CodecTo: record.data.codecTo,
        User_Name: "",
        Password: "",
        AuthID: "",
        Type: "register_trunk",
        Need_Registration: true,
        Port: 5060,
        Server_Address: "",
        Out_Proxy_Server: "",
        Out_Proxy_Port: "",
        Transport: "udp",
        KA_Freq: ""
    })

    const codecoptions = record.data.codecFrom || []
    const options = codecoptions.map((e) => {
        return { value: e, label: e }
    })

    const TrunkSchema = yup.object().shape({
        KA_Freq: yup.number().typeError("KA Freq Must be number")
            .when("Enable_KA", {
                is: true,
                then: yup.number().required("KA Freq is required when fk is checked")
            }),
        Name: yup.string().required("Name is Requierd"),

        Port: yup.number().typeError("Port Must be number")
            .when("Need_Registration", {
                is: true,
                then: yup.number().typeError("Port Must be number").required("Port is Requierd when Need Register is checked")
            }).when("Type", {
                is: "peer_trunk",
                then: yup.number().typeError("Port Must be number").required("Port is requierd")
            }),

        Server_Address: yup.string()
            .when("Need_Registration", {
                is: true,
                then: yup.string().required("Server Address is Requierd when Need Register is checked")
            }).when("Type", {
                is: "peer_trunk",
                then: yup.string().required("Server Address is requierd")
            }),

        User_Name: yup.string().when("Type", {
            is: "register_trunk",
            then: yup.string().required("User Name is requierd")
        }),

        Password: yup.string().when("Type", {
            is: "register_trunk",
            then: yup.string().required("Password is requierd")
        }),

        A_CodecTo: yup.array()
            .of(yup.string())
            .min(1, "Must select at least one codec")
            .required("Must select at least one codec")

    })

    const [peer, setPeer] = useState(true)

    const toggle = tab => {
        if (active !== tab) {
            setActive(tab)
        }
    }

    const handleData = (e) => {
        setTrunkstate({ ...trunkstate, [e.target.name]: e.target.value })
    }
    const handleCheckbox = (e) => {
        setTrunkstate({ ...trunkstate, [e.target.name]: e.target.checked })
    }
    const handleSubmit = async (values) => {
        console.log(trunkstate)
        await createTrunk(trunkstate)
        history.push("/trunk")
    }

    const handleCancel = () => {
        history.push("/trunk")
    }

    return (
        <>
            <Formik
                validationSchema={TrunkSchema}
                initialValues={trunkstate}
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
                                    <CardTitle tag='h4'>New Trunk
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
                                                    <span className='align-middle'>Advanced</span>
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
                                                    <Col md='2' sm='12'>
                                                        <CustomInput inline={true} type='checkbox'
                                                            name="Enable_Trunk"
                                                            id='exampleCustomCheckbox1'
                                                            onChange={handleCheckbox}
                                                            label='Enable Trunk'
                                                            checked={trunkstate.Enable_Trunk}
                                                        />
                                                    </Col>
                                                    <Col md='2' sm='12' className='mb-1'>
                                                        <Label>Type</Label>
                                                        <Input type='select' name='Type' value={trunkstate.Type} onChange={handleData} id='select-basic'>
                                                            <option value="register_trunk">Register Trunk</option>
                                                            <option value="peer_trunk">Peer Trunk</option>
                                                        </Input>
                                                    </Col>
                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Name</Label>
                                                        <Input type='text'
                                                            name='Name'
                                                            id='Name'
                                                            value={trunkstate.Name}
                                                            invalid={errors.Name && touched.Name}
                                                            placeholder='Trunk Name'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Name && touched.Name && (
                                                            <FormFeedback>{errors.Name}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    {trunkstate.Need_Registration || trunkstate.Type === 'peer_trunk' ? <>
                                                        <Col md='3' sm='12' className='mb-1'>
                                                            <Label><span className="text-danger">*</span> Server Address</Label>
                                                            <Input type='text'
                                                                name='Server_Address'
                                                                id='Server_Address'
                                                                value={trunkstate.Server_Address}
                                                                invalid={errors.Server_Address && touched.Server_Address}
                                                                placeholder='Server Address'
                                                                onChange={handleData}
                                                            />
                                                            {errors.Server_Address && touched.Server_Address && (
                                                                <FormFeedback>{errors.Server_Address}</FormFeedback>
                                                            )}
                                                        </Col>

                                                        <Col md='2' sm='12' className='mb-1'>
                                                            <Label> <span className="text-danger">*</span> Port</Label>
                                                            <Input type='text'
                                                                name='Port'
                                                                id='Port'
                                                                value={trunkstate.Port}
                                                                invalid={errors.Port && touched.Port}
                                                                placeholder='Port'
                                                                onChange={handleData}
                                                            />
                                                            {errors.Port && touched.Port && (
                                                                <FormFeedback>{errors.Port}</FormFeedback>
                                                            )}
                                                        </Col>
                                                    </> : ''}

                                                </Row>
                                                <Row>
                                                    <Col md='2' sm='12'>
                                                        <CustomInput inline={true} type='checkbox'
                                                            name="Enable_KA"
                                                            id='exampleCustomCheckbox2'
                                                            onChange={handleCheckbox}
                                                            label='Enable Keep-alive'
                                                            checked={trunkstate.Enable_KA}
                                                        />
                                                    </Col>

                                                    <Col md='2' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Keep-alive Frequency</Label>
                                                        <Input
                                                            type='text'
                                                            name='KA_Freq'
                                                            id='KA_Freq'
                                                            readOnly={!trunkstate.Enable_KA}
                                                            value={trunkstate.Enable_KA ? trunkstate.KA_Freq : 60}
                                                            invalid={errors.KA_Freq && touched.KA_Freq}
                                                            placeholder='Keep-alive Frequency'
                                                            onChange={handleData}
                                                        />
                                                        {errors.KA_Freq && touched.KA_Freq && (
                                                            <FormFeedback>{errors.KA_Freq}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Out Proxy Server</Label>
                                                        <Input type='text'
                                                            name='Out_Proxy_Server'
                                                            id='Out_Proxy_Server'
                                                            value={trunkstate.Out_Proxy_Server}
                                                            placeholder='Out Proxy Server'
                                                            onChange={handleData}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Out Proxy Port</Label>
                                                        <Input type='text'
                                                            name='Out_Proxy_Port'
                                                            id='Out_Proxy_Port'
                                                            value={trunkstate.Out_Proxy_Port}
                                                            placeholder='Out Proxy Port'
                                                            onChange={handleData}
                                                        />
                                                    </Col>
                                                    {trunkstate.Need_Registration || trunkstate.Type === 'peer_trunk' ? <Col md='2' sm='12' className='mb-1'>
                                                        <Label>Transport</Label>
                                                        <Input type='select' name='Transport' value={trunkstate.Transport} onChange={handleData} id='select-basic'>
                                                            <option value="udp">UDP</option>
                                                            <option value="tls">TLS</option>
                                                            <option value="tcp">TCP</option>
                                                        </Input>
                                                    </Col> : ''}

                                                </Row>

                                                <div className='panal-title'>
                                                    <span className="text-primary font-wegiht-bolder">| </span>
                                                    User Setting
                                                </div>
                                                <br />
                                                {trunkstate.Type === 'register_trunk' ? <Row>
                                                    <Col md='2' sm='12'>
                                                        <CustomInput inline={true} type='checkbox'
                                                            name="Need_Registration"
                                                            id='exampleCustomCheckbox3'
                                                            onChange={handleCheckbox}
                                                            label='Need Registration'
                                                            checked={trunkstate.Need_Registration}
                                                        />
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> User Name</Label>
                                                        <Input type='text'
                                                            name='User_Name'
                                                            id='User_Name'
                                                            value={trunkstate.User_Name}
                                                            invalid={errors.User_Name && touched.User_Name}
                                                            placeholder='User Name'
                                                            onChange={handleData}
                                                        />
                                                        {errors.User_Name && touched.User_Name && (
                                                            <FormFeedback>{errors.User_Name}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label><span className="text-danger">*</span> Password</Label>
                                                        <Input type='text'
                                                            name='Password'
                                                            id='Password'
                                                            value={trunkstate.Password}
                                                            invalid={errors.Password && touched.Password}
                                                            placeholder='Password'
                                                            onChange={handleData}
                                                        />
                                                        {errors.Password && touched.Password && (
                                                            <FormFeedback>{errors.Password}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>Auth ID</Label>
                                                        <Input type='text'
                                                            name='AuthID'
                                                            id='AuthID'
                                                            value={trunkstate.AuthID}
                                                            placeholder='AuthID'
                                                            onChange={handleData}
                                                        />
                                                    </Col>
                                                </Row> : ''}
                                            </TabPane>
                                            <TabPane tabId='2'>
                                                <div className='panal-title'>
                                                    <span className="text-primary font-wegiht-bolder">| </span>
                                                    General
                                                </div>
                                                <br />
                                                <Row>
                                                    <Col md='2' inline="true" sm='12'>
                                                        <CustomInput type='checkbox'
                                                            name="Enable_NAT"
                                                            id='exampleCustomCheckbox5'
                                                            onChange={handleCheckbox}
                                                            label='NAT'
                                                            checked={trunkstate.Enable_NAT}
                                                        />
                                                    </Col>
                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>From User</Label>
                                                        <Input type='text'
                                                            name='From_User'
                                                            id='From_User'
                                                            value={trunkstate.From_User}
                                                            invalid={errors.From_User && touched.From_User}
                                                            placeholder='From User'
                                                            onChange={handleData}
                                                        />
                                                        {errors.From_User && touched.From_User && (
                                                            <FormFeedback>{errors.From_User}</FormFeedback>
                                                        )}
                                                    </Col>

                                                    <Col md='3' sm='12' className='mb-1'>
                                                        <Label>From Domain</Label>
                                                        <Input type='text'
                                                            name='From_Domain'
                                                            id='From_Domain'
                                                            value={trunkstate.From_Domain}
                                                            invalid={errors.From_Domain && touched.From_Domain}
                                                            placeholder='From Domain'
                                                            onChange={handleData}
                                                        />
                                                        {errors.From_Domain && touched.From_Domain && (
                                                            <FormFeedback>{errors.From_Domain}</FormFeedback>
                                                        )}
                                                    </Col>
                                                    <Col md='2' sm='12' className='mb-1'>
                                                        <Label>SRTP</Label>
                                                        <Input type='select' name='SRTP' value={trunkstate.SRTP} onChange={handleData} id='select-basic'>
                                                            <option value="1">Disabled</option>
                                                            <option value="2">Enable</option>
                                                            <option value="3">Optional</option>
                                                            <option value="4">Force</option>
                                                        </Input>
                                                    </Col>
                                                    <Col md='2' sm='12' className='mb-1'>
                                                        <Label>DTMF Mode</Label>
                                                        <DtmfsSelect name='DTMF_ModeId' value={trunkstate.DTMF_ModeId} handleOnChange={handleData} />
                                                    </Col>
                                                </Row>
                                                <Row>
                                                    <Col md='9' sm='12' className='mt-1'>
                                                        <Label for='codec'>Codec</Label>
                                                        <DualListBox
                                                            id="preserve-order"
                                                            options={options}
                                                            preserveSelectOrder
                                                            selected={trunkstate.A_CodecTo}
                                                            showOrderButtons
                                                            onChange={(newValue) => setTrunkstate(prevSetting => ({
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

export default TrunkForm
