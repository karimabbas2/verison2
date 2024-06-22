import { Check } from "react-feather"
import * as api from "../../../../api/index"
import Avatar from '@components/avatar'
import { toast } from 'react-toastify'
import SuccessToast from "../../../ToasterMessage/SuccessToast"

export const getallRequierdData = () => {
    return async dispatch => {
        await api.RequierdData().then((response) => {
            // console.log(response)
            const data = response.data
            dispatch({
                type: 'GET_ALL_REQUIERD_DATA',
                data
            })

        }).catch((err) => {
            console.log(err)
        })
    }
}

export const getRecord = () => {
    return async dispatch => {
        await api.Record().then((response) => {
            const data = response.data
            dispatch({
                type: 'GET_RECORD',
                data
            })
        }).catch((err) => {
            console.log(err)
        })
    }
}

export const updateRecord = (data) => {
    return async dispatch => {
        await api.UpdateRecord(data).then((response) => {
            const data = response.data
            if (response.status === 200) {
                console.log(data)
                dispatch({
                    type: 'UPDATE_RECORD',
                    data
                })

                toast.success(<SuccessToast msg="Default Setting Updated Successfully" />, { hideProgressBar: true })
            }

        }).catch((err) => {
            console.log(err)
            // const data = err.response.data.errors
            // console.log(data)
            // dispatch({
            //     type: 'ERROR',
            //     data
            // })
        })
    }
}

