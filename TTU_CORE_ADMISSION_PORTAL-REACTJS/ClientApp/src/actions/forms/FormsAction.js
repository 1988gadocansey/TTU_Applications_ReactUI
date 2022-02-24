import { Types } from './Types'
import api from '../../utils/api'
import API from "../../utils/api";

export const addForm = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        API().post('/forms', values).then((res) => {
            dispatch({
                type: Types.NEW_FORM,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
// fetch details of user form
export const setFormData = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        API.put(`/forms/${values.id}`, values).then((res) => {
            dispatch({
                type: Types.SET_FORM_DATA,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
// update the details of user form
export const updateForm = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        api().put(`/forms/${values.id}`, values).then((res) => {
            dispatch({
                type: Types.SET_FORM_DATA,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
// preview user form details
export const setFormDetails = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        API.put(`/preview/${values.id}`, values).then((res) => {
            dispatch({
                type: Types.SET_FORM_DATA,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
