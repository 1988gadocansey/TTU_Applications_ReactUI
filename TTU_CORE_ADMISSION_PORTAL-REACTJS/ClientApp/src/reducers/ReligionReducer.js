import {Types} from '../actions/religions/Types'
const initialState = {
    choices: {},
}
export default function religionReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_RELIGION:
            return {...state, choices: payload};

        default:
            return state
    }
}
