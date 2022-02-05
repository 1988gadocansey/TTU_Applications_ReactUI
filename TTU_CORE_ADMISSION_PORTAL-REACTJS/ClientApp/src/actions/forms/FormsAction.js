import { Types } from './Types'
import api from '../../utils/api'

export const addForm = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        api().post('/forms', values).then((res) => {
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

export const setFormData = (values) => (dispatch) => {
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

export const setFormDetails = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        api().put(`/preview/${values.id}`, values).then((res) => {
            dispatch({
                type: Types.GET_FORM_DETAIL,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
