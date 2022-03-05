import {Types} from '../actions/shsprogrammes/Types'
const initialState = {
    choices: {},
}
export default function shsprogrammerReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_SHSPROGRAMME:
            return {...state, choices: payload};

        default:
            return state
    }
}
