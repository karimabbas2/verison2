const initialState = {
    all_dtmfs: [],
    all_privileges: [],
    all_jitterBuffers: []
}

const RequierdDataStore = (state = initialState, action) => {
    switch (action.type) {
        case 'GET_ALL_REQUIERD_DATA':
            return {
                ...state, all_dtmfs: action.data.dtmFs, all_privileges: action.data.privileges, all_jitterBuffers: action.data.jitterBuffers
            }
        default:
            return { ...state }
    }
}
export default RequierdDataStore