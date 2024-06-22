const initialState = {
    data: [],
    columns: [],
    loading: false,
    selectedItem: {}
}

const VoicePromptsStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Voices':
            return { ...state, data: action.data, columns: action.columns, selectedItem: {} }

        case 'Delete_Voice':
            const result = state.data.filter((x) => x.id !== action.id)
            return { ...state, data: result }

        case 'Get_EXT':
            return { ...state, selectedItem: action.selectedItem }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state }
    }

}
export default VoicePromptsStore