import { Types } from './Types'
import api from '../../utils/api'

export const addResults = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        api().post('/Result', values).then((res) => {
            dispatch({
                type: Types.NEW_RESULT,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}


export const getAllResult = () => async (dispatch) => {
    await api().get('/Results')
        .then((res) => {
            dispatch({
                type: Types.SET_RESULT,
                payload: res.data
            })
        })
}
