const initialState = {
    data: []
}

const GlobalSettingStore = (state = initialState, action) => {
    switch (action.type) {
        case 'GET_RECORD':
            return { ...state, data: action.data }
        case 'UPDATE_RECORD':
            return { ...state, data: action.data }
        default:
            return { ...state }
    }
}
export default GlobalSettingStore