import { date } from "yup"

const initialState = {
    data: [],
    columns: [],
    loading: false,
    selectedItem: {}
}

const ExtStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_EXT':
            // console.log(action.data)
            let LastExtNumber = action.data[action.data.length - 1]
            let num = LastExtNumber.ext_Number
            localStorage.setItem("LastExtNumber", num + 1)
            return { ...state, data: action.data, columns: action.columns, selectedItem: {} }

        case 'Delete_EXT':
            const result = state.data.filter((x) => x.id !== action.id)
            LastExtNumber = result[result.length - 1]
            num = LastExtNumber.ext_Number
            localStorage.setItem("LastExtNumber", num + 1)
            return { ...state, data: result }

        case 'Get_EXT':
            // console.log(action.myid)
            // const item = state.data.filter((x) => x.id === action.myid)
            return { ...state, selectedItem: action.selectedItem }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state }
    }

}
export default ExtStore