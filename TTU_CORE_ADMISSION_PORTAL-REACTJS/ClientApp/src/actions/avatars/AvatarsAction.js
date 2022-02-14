import { Types } from './Types'
import API from "../../utils/api";
export const  uploadPhoto = (dispatch) => async () => {
    await API.get('/applicationform')
        .then((res) => {
            dispatch({
                type: Types.GET_USER,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })

}