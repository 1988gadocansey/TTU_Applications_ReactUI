import {Types} from '../actions/applicant/Types'
const initialState = {
    applicantInfo: {},
}
export default function applicantReducer(state = initialState,  {type, payload}) {
    switch (type) {
        case Types.GET_DATA:
            return {...state, applicantInfo: payload};

        default:
            return state
    }
}
