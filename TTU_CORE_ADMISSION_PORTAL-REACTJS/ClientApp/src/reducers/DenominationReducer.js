import {Types} from '../actions/denominations/Types'
const initialState = {
    choices: {},
}
export default function denominationReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_DENOMINATION:
            return {...state, choices: payload};

        default:
            return state
    }
}
