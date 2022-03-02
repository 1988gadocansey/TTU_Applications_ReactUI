import {Types} from '../actions/programmes/Types'
const initialState = {
    programmes: {},
}
export default function programmerReducer(state = initialState, action) {
    switch (action.type) {
        case Types.GET_PROGRAMME:
            return {...state, programmes: payload};
        
        default:
            return state
    }
}
