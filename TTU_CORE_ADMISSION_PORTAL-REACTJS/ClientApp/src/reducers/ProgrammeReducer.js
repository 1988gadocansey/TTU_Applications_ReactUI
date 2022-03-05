import {Types} from '../actions/programmes/Types'
const initialState = {
    choices: {},
}
export default function programmerReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_PROGRAMME:
            return {...state, choices: payload};
        
        default:
            return state
    }
}
