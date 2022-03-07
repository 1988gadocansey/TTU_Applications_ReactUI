import {Types} from '../actions/grades/Types'
const initialState = {
    choices: {},
}
export default function gradeReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_GRADE:
            return {...state, choices: payload};

        default:
            return state
    }
}
