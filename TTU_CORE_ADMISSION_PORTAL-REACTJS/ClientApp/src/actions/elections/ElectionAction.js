import { Types } from './Types'
import api from '../../utils/api'

export const getAllElections = () => async (dispatch) => {
  await api().get('/elections')
    .then((res) => {
      dispatch({
        type: Types.GET_ALL_ELECTIONS,
        payload: res.data
      })
    })
}

export const addNewElection = (values) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().post('/elections', values).then((res) => {
      dispatch({
        type: Types.NEW_ELECTION,
        payload: res.data
      })
      resolve()
    }).catch((err) => {
      reject(err)
    })
  })
}

export const setElectionData = (values) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().put(`/elections/${values.id}`, values).then((res) => {
      dispatch({
        type: Types.SET_ELECTION_DATA,
        payload: res.data
      })
      resolve()
    }).catch((err) => {
      reject(err)
    })
  })
}

export const getElectionDetail = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().get(`/elections/${id}`).then((res) => {
      dispatch({
        type: Types.GET_ELECTION_FOR_STAT,
        payload: res.data
      })
      resolve()
    }).catch((err) => {
      reject(err)
    })
  })
}
export const deleteElection = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().delete(`/elections/${id}`).then((res) => {
      dispatch({
        type: Types.DELETE_ELECTION,
        payload: id
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}

export const getPortfolios = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().get(`/election/portfolios/${id}`).then((res) => {
      dispatch({
        type: Types.GET_PORTFOLIOS,
        payload: res.data
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}

export const addPortfolios = (values) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().post('/election/portfolios', values).then((res) => {
      dispatch({
        type: Types.ADD_PORTFOLIOS,
        payload: res.data
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}

export const removePortfolio = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().delete(`/election/portfolios/${id}`).then((res) => {
      dispatch({
        type: Types.REMOVE_PORTFOLIO,
        payload: res.data
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}

export const allPortfolios = (id) => (dispatch) => {
  return new Promise((resolve, reject) => {
    api().get(`/election/portfolios/${id}`).then((res) => {
      dispatch({
        type: Types.GET_PORTFOLIOS,
        payload: id
      })
      resolve(res)
    }).catch((err) => {
      reject(err)
    })
  })
}
