import { Types } from './Types'
import api from '../../utils/api'

export const getAllNominees = (path) => async (dispatch) => {
  await api().get(`/${path}`)
    .then((res) => {
      dispatch({
        type: Types.GET_ALL_NOMINEES,
        payload: res.data
      })
    })
}

export const updateNomineeInfo = (values) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().put(`/candidates/${values.id}`, values).then((res) => {
      dispatch({
        type: Types.SET_NOMINEE_DATA,
        payload: res.data
      })
      resolve()
    }).catch((err) => {
      reject(err)
    })
  })
}

export const setNomineeData = (values) => (dispatch) => {
  return new Promise((resolve, reject) => {
    dispatch({
      type: Types.SET_NOMINEE_DATA,
      payload: values
    })
    resolve(values)
  })
}

export const getNomineeDetail = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().get(`/candidates/${id}`).then((res) => {
      dispatch({
        type: Types.SET_NOMINEE_DATA,
        payload: res.data
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}
export const makeCandidate = (data) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().post(`/nominee/${data.candidateId}/make-candidate`, data).then((res) => {
      dispatch({
        type: Types.MAKE_CANDIDATE,
        payload: res.data
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}
