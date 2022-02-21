import {Types} from '../actions/avatars/Types'

const initialState = {
    photo: []
}

function avatarReducer(state = initialState, {type, payload}) {
    switch (type) {
        case Types.UPLOAD_AVATAR:
            return {...state, photo: payload};
        case Types.SHOW_AVATAR:
            return {...state, photo: payload};    
        default:
            return state;
    }
}

export default avatarReducer