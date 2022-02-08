import {Types} from '../actions/user/Types'

const initialState = {
    loggedInUser: []
}

function userReducer(state = initialState, {type, payload}) {
    switch (type) {
        case Types.GET_USER:
            return {...state, loggedInUser: payload};
        default:
            return state;
    }
}

export default userReducer