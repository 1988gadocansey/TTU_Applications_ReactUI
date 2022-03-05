import {Types} from '../actions/years/Types'
const initialState = {
    choices: {},
}
export default function yearReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_YEARS:
            return {...state, choices: payload};

        default:
            return state
    }
}
