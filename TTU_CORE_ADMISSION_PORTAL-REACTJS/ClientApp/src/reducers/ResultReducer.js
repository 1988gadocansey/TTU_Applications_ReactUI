import {Types} from '../actions/results/Types'

const initialState = {
    newResult: {},
    resultData: {},
    deleteResult: {},
}
export default function formReducer(state = initialState, action) {
    switch (action.type) {
        case Types.NEW_RESULT:
            return {...state, result: state.result.concat(action.payload)}
        case Types.SET_RESULT:
            return {
                ...state,
                result: state.result.map((result) => {
                    return result.id === action.payload.id ? action.payload : result
                })
            }
        case Types.DELETE_RESULT:
            return {...state, result: state.result.filter((result) => result.id !== action.payload)}

        default:
            return state
    }
}
