const initialState = {
    errors: {}
}

const HandleError = (state = initialState, action) => {
    switch (action.type) {
        case 'ERROR':
            return { ...state, errors: action.data }
        case "CLEAR_ERROR":
            return { ...state, errors: '' }
        default:
            return { ...state }
    }
}
export default HandleError