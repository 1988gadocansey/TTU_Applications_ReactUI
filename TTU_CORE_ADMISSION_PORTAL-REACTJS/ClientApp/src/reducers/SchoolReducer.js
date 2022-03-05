import {Types} from '../actions/schools/Types'
const initialState = {
    choices: {},
}
export default function schoolReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_SCHOOL:
            return {...state, choices: payload};

        default:
            return state
    }
}
