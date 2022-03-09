import { Types } from './Types'
import API from "../../utils/api";

// preview user form details
export const setFormDetails = (values) => (dispatch) => {
    return new Promise((resolve, reject) => {
        API.put(`preview`, values).then((res) => {
            dispatch({
                type: Types.GET_DATA,
                payload: res.data
            })
            resolve()
        }).catch((err) => {
            reject(err)
        })
    })
}
