import * as api from "../../api/index"
import { toast } from 'react-toastify'
import SuccessToast from "../ToasterMessage/SuccessToast"

export const applayChanges = () => async (dispatch) => {
    await api.ApplayChanges().then(res => {
        // console.log(res)
        if (res.status === 200) {
            dispatch({
                type: 'Applay_Changes_Click',
                status: false
            })
            toast.success(<SuccessToast msg={res.data.message} />, { hideProgressBar: true })
        }
    }).catch((err) => {
        console.log(err)
    })
}