import * as api from "../../../api/index"
import { Trunkcolumns } from "../columns"

export const getAllTrunks = () => {
    return async dispatch => {
        dispatch({
            type: 'SET_LOADING'
        })
        await api.GetAllTrunks().then((response) => {
            const data = response.data
            console.log(data)
            const columns = Trunkcolumns()
            dispatch({
                type: 'Get_All_Trunk',
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

export const createTrunk = (data) => {
    return async dispatch => {
        await api.CreateTrunk(data).then(res => {
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