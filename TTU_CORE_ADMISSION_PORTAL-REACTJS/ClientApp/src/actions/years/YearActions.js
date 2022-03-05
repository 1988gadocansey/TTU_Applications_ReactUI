import API from "../../utils/api";
import {Types} from './Types'

export const  getYears = (dispatch) => async () => {
    await API.get('/api/selectbox/years')
        .then((res) => {
            dispatch({
                type: Types.GET_YEARS,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })


}