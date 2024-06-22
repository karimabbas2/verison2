const initialState = {
    status: false
}

const ConfigFileStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Applay_Changes':
            return { ...state, status: action.status }
        case 'Applay_Changes_Click':
            return { ...state, status: action.status }
        default:
            return { ...state }
    }

}
export default ConfigFileStore