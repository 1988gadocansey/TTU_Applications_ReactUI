import {Types} from '../actions/subjects/Types'
const initialState = {
    choices: {},
}
export default function subjectReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_SUBJECT:
            return {...state, choices: payload};

        default:
            return state
    }
}
