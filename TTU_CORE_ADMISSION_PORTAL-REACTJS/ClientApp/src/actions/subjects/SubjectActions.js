import { Types } from './Types'
import API from "../../utils/api";
export const  getSubject = (dispatch) => async () => {
    await API.get('/api/selectbox/subjects')
        .then((res) => {
            dispatch({
                type: Types.GET_SUBJECT,
                payload: res.data
            })

        }).catch((err) => {
            console.log("error",err)
        })
    

}
 