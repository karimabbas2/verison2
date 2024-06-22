
const initialState = {
    data: []
}

const SIPSettingStore = (state = initialState, action) => {
    switch (action.type) {
        case 'GET_SIP_RECORD':
            return { ...state, data: action.data }
        case 'UPDATE_SIP_RECORD':
            return { ...state, data: action.data }
        default:
            return { ...state }
    }
}
export default SIPSettingStore