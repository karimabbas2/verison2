const initialState = {
    data: [],
    columns: [],
    loading: false,
    selectedItem: {}
}

const TrunkStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Trunk':
            return { ...state, data: action.data, columns: action.columns, selectedItem: {} }

        case 'Delete_Trunk':
            const result = state.data.filter((x) => x.id !== action.id)
            return { ...state, data: result }

        case 'Get_Trunk':
            return { ...state, selectedItem: action.selectedItem }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state }
    }

}
export default TrunkStore