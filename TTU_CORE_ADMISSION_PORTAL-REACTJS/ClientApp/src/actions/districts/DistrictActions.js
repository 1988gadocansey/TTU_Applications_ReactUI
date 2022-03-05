import { Types } from './Types'
import API from "../../utils/api";
export const  getDistrict = (dispatch) => async () => {
    await API.get('/api/selectbox/districts')
        .then((res) => {
            dispatch({
                type: Types.GET_DISTRICT,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 