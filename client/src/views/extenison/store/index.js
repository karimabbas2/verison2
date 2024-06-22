import { useHistory } from "react-router-dom/cjs/react-router-dom.min"
import * as api from "../../../api/index"
import SuccessToast from "../../ToasterMessage/SuccessToast"
import { Extcolumns } from "../columns"
import { toast } from 'react-toastify'
import DeleteSwal from "../../ToasterMessage/DeleteSwal"

export const getAllExtenstion = (handleExtDelete) => {
    return async dispatch => {
        dispatch({
            type: 'SET_LOADING'
        })
        await api.GetAllExt().then((response) => {
            const data = response.data
            // console.log(data)
            const columns = Extcolumns(handleExtDelete)
            dispatch({
                type: 'Get_All_EXT',
                data,
                columns

            })
            dispatch({
                type: 'UNSET_LOADING'
            })
        }).catch((err) => {
            console.log(err)
        })
    }
}

export const createExt = (data) => {
    return async dispatch => {
        await api.CreateExt(data).then(res => {
            console.log(res)
            if (res.status === 200) {
                dispatch({
                    type: 'Applay_Changes',
                    status: true
                })
                toast.success(<SuccessToast msg={res.data.message} />, { hideProgressBar: true })

            }
        }).catch((err) => {
            console.log(err)
        })
    }
}

export const updateExt = (id, data) => {
    return async dispatch => {
        await api.UpdateExt(id, data).then(response => {
            // console.log(response)
            if (response.status === 200) {
                dispatch({
                    type: 'Applay_Changes',
                    status: true
                })
                toast.success(<SuccessToast msg={response.data.message} />, { hideProgressBar: true })
            }
        }).catch((err) => {
            console.log(err)
        })
    }
}

export const deleteExt = (id) => async (dispatch) => {
    await api.DeleteExt(id).then(res => {
        // console.log(res)
        if (res.status === 200) {
            dispatch({
                type: 'Applay_Changes',
                status: true
            })
            toast.success(<SuccessToast msg={res.data.message} />, { hideProgressBar: true })
            dispatch({
                type: 'Delete_EXT',
                id
            })
        }
    }).catch((err) => {
        console.log(err)
    })
}

export const getExt = (id) => async (dispatch) => {
    await api.GetExt(id).then(res => {
        const data = res.data
        // console.log(data)
        if (res.status === 200) {
            dispatch({
                type: 'Get_EXT',
                selectedItem: data
            })
        }
    }).catch((err) => {
        console.log(err)
    })
}

export const setLoading = () => {
    return async dispatch => {
        dispatch({
            type: 'SET_LOADING'
        })
    }
}

export const unSetLoading = () => {
    return async dispatch => {
        dispatch({
            type: 'UNSET_LOADING'
        })
    }
}