import {Types} from '../actions/districts/Types'
const initialState = {
    choices: {},
}
export default function districtReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_DISTRICT:
            return {...state, choices: payload};

        default:
            return state
    }
}
