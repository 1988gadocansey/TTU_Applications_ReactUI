import { Types } from './Types'
import API from "../../utils/api";
export const  getReligion = (dispatch) => async () => {
    await API.get('/api/selectbox/religions')
        .then((res) => {
            dispatch({
                type: Types.GET_RELIGION,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 