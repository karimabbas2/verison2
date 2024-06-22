import React, { useState, useEffect } from 'react'
import { Card, CardHeader, CardTitle, CardBody, Label, Button, Row, Col, FormGroup, Input, CustomInput, FormFeedback } from 'reactstrap'
import {
  AvForm,
  AvGroup,
  AvField,
  AvInput,
  AvFeedback,
  AvRadioGroup,
  AvCheckboxGroup,
  AvRadio,
  AvCheckbox
} from 'availity-reactstrap-validation-safe'
import { Formik, Form } from 'formik'
import * as yup from 'yup'
import { useDispatch, useSelector } from 'react-redux'
import { getSipSetting, updateSipRecord } from './store/action'
import { number } from 'prop-types'
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min'

function index() {

  const dispatch = useDispatch()
  const hisyory = useHistory()
  const SipRecord = useSelector(state => state.SIPSettingStore)
  // console.log(SipRecord)

  const [sipsetting, setSipSetting] = useState({
    Id: '',
    UDP_PORT: '',
    TCP_PORT: '',
    TLS_PORT: '',
    RTP_Range_From: '',
    RTP_Range_TO: '',
    STUN_Address: ''
  })
  useEffect(() => {
    if (SipRecord.data) {
      setSipSetting({
        Id: SipRecord.data.id,
        UDP_PORT: SipRecord.data.udP_PORT,
        TCP_PORT: SipRecord.data.tcP_PORT,
        TLS_PORT: SipRecord.data.tlS_PORT,
        RTP_Range_From: SipRecord.data.rtP_Range_From,
        RTP_Range_TO: SipRecord.data.rtP_Range_TO,
        STUN_Address: SipRecord.data.stuN_Address
      })
    }
  }, [SipRecord])

  // console.log(sipsetting)

  const SipSettingschema = yup.object().shape({
    UDP_PORT: yup.number().typeError("Enter Valid Number").required("Field is Requierd"),
    TCP_PORT: yup.number().typeError("Enter Valid Number").required("Field is Requierd"),
    TLS_PORT: yup.number().typeError("Enter Valid Number").required("Field is Requierd"),
    RTP_Range_From: yup.number().typeError("Enter Valid Number").required("Field is Requierd"),
    RTP_Range_TO: yup.number().typeError("Enter Valid Number").required("Field is Requierd").integer()
      .moreThan(yup.ref('RTP_Range_From'), 'RTP Range TO must be greater than RTP Range From')
  })

  const handleData = (e) => {
    setSipSetting({ ...sipsetting, [e.target.name]: e.target.value })
  }

  const handleSubmit = (values) => {
    dispatch(updateSipRecord(sipsetting))
  }
  const handleCanel = () => {
    hisyory.push("/")
  }

  return (
    <>
      <Formik
        validationSchema={SipSettingschema}
        initialValues={sipsetting}
        enableReinitialize={true}
        onSubmit={(values) => {
          handleSubmit(values)
          // resetForm()
        }}
        validateOnBlur={true}
        validateOnChange={true}

      >
        {({ errors, touched, handleBlur, isValid }) => {
          return (

            <Card>
              <CardHeader>
                <CardTitle tag='h4'>Session Initiation Protocol Setting
                </CardTitle>
              </CardHeader>

              <CardBody>
                <Form>
                  <FormGroup row className='mb-1'>
                    <Label sm='2' for='UDP_PORT'><span className="text-danger">*</span> UDP Port</Label>
                    <Col sm='3'>
                      <Input type='number'
                        name='UDP_PORT'
                        onBlur={handleBlur}
                        value={sipsetting.UDP_PORT}
                        onChange={handleData}
                        invalid={errors.UDP_PORT && touched.UDP_PORT}
                        id='UDP_PORT' />
                      {/* {console.log(touched.UDP_PORT)} */}
                      {errors && errors.UDP_PORT && touched.UDP_PORT && (
                        <FormFeedback>{errors.UDP_PORT}</FormFeedback>
                      )}
                    </Col>
                  </FormGroup>

                  <FormGroup row className='mb-1'>
                    <Label sm='2' for='TCP_PORT'><span className="text-danger">*</span> TCP Port</Label>
                    <Col sm='3'>
                      <Input type='number'
                        name='TCP_PORT'
                        value={sipsetting.TCP_PORT}
                        invalid={errors.TCP_PORT && true}
                        onChange={handleData}
                        id='TCP_PORT' />
                      <FormFeedback>{errors.TCP_PORT}</FormFeedback>
                    </Col>
                  </FormGroup>

                  <FormGroup row className='mb-1'>
                    <Label sm='2' for='TLS_PORT'><span className="text-danger">*</span> TLS Port</Label>
                    <Col sm='3'>
                      <Input type='TLS_PORT'
                        name='TLS_PORT'
                        value={sipsetting.TLS_PORT}
                        invalid={errors.TLS_PORT && true}
                        onChange={handleData}
                        id='TLS_PORT' />
                      <FormFeedback>{errors.TLS_PORT}</FormFeedback>
                    </Col>
                  </FormGroup>

                  <FormGroup row className='mb-1'>
                    <Label sm='2' for='RTP_Range_From'> <span className="text-danger">*</span> RTP Range</Label>
                    <Col sm='3'>
                      <Input type='number'
                        name='RTP_Range_From'
                        value={sipsetting.RTP_Range_From}
                        onChange={handleData}
                        invalid={errors.RTP_Range_From && true}
                        id='RTP_Range_From' />
                      <FormFeedback>{errors.RTP_Range_From}</FormFeedback>
                    </Col>
                    <span>_</span>
                    <Col sm='3'>
                      <Input type='number'
                        name='RTP_Range_TO'
                        value={sipsetting.RTP_Range_TO}
                        onChange={handleData}
                        invalid={errors.RTP_Range_TO && true}
                        id='RTP_Range_TO' />
                      <FormFeedback>{errors.RTP_Range_TO}</FormFeedback>

                    </Col>
                  </FormGroup>

                  <FormGroup row className='mb-1'>
                    <Label sm='2' for='STUN_Address'>STUN Address</Label>
                    <Col sm='3'>
                      <Input type='text'
                        name='STUN_Address'
                        value={sipsetting.STUN_Address}
                        onChange={handleData}
                        id='STUN_Address' />
                    </Col>
                  </FormGroup>
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
                </Form>
              </CardBody>
            </Card>
          )
        }}
      </Formik>

    </>
  )
}

export default index