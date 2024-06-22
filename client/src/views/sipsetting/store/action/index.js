
import * as api from "../../../../api/index"
import { toast } from 'react-toastify'
import SuccessToast from "../../../ToasterMessage/SuccessToast"

export const getSipSetting = () => {
    return async dispatch => {
        await api.GetSipSetting().then((response) => {
            // console.log(response)
            const data = response.data
            // localStorage.setItem("applay_SIP", false)
            dispatch({
                type: 'GET_SIP_RECORD',
                data
            })
        }).catch((err) => {
            console.log(err)
        })
    }
}

export const updateSipRecord = (data) => {
    return async dispatch => {
        await api.UpdateSipSetting(data).then((response) => {
            const data = response.data
            if (response.status === 200) {
                localStorage.setItem("applay_SIP", true)
                dispatch({
                    type: 'UPDATE_SIP_RECORD',
                    data
                })
                toast.success(<SuccessToast msg="SIP Setting Updated successfully" />, { hideProgressBar: true })
            }

        }).catch((err) => {
            console.log(err)
        })
    }
}

export const applaySIPChanges = async () => {
    try {
        const response = await api.ApplaySIPChanges()
        console.log(response)
        if (response.status === 200) {
            toast.success(<SuccessToast msg={response.data.message} />, { hideProgressBar: true })
        }
    } catch (err) {
        console.log(err)
    }
}

export const rebootSystem = async () => {
    try {
        const response = await api.RebootSystem()
        if (response.status === 200) {
            localStorage.setItem("applay_SIP", false)
            return (
                <>
                    <div className=' text-center p-lg-4 mt-5 b-transparent center' >
                        <Spinner color='danger custom-spinner-loading' />
                        <span>Wating...</span>
                    </div >
                </>
            )

        }
    } catch (error) {
        console.log(err)
    }
}