import {Types} from '../actions/forms/Types'
const initialState = {
    newForm: {},
    formContent: {},
    formDetail: {},
}
export default function formReducer(state = initialState, action) {
    switch (action.type) {
        case Types.NEW_FORM:
            return {...state, form: state.form.concat(action.payload)}
        case Types.SET_FORM_DATA:
            return {
                ...state,
                form: state.form.map((form) => {
                    return form.id === action.payload.id ? action.payload : form
                })
            }
        case Types.GET_FORM_DETAIL:
            return {...state, formDetail: action.payload}

        default:
            return state
    }
}
