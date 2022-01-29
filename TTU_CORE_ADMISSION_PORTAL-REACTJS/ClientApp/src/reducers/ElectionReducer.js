import { Types } from '../actions/elections/Types'
const initialState = {
  elections: [],
  newElection: {},
  electionData: {},
  electionDetail: {},
  electionDetailForStat: {},
  electionPortFolios: [],
  otherPortFolios: []
}

export default function electionReducer (state = initialState, action) {
  switch (action.type) {
    case Types.GET_ALL_ELECTIONS:
      return { ...state, elections: action.payload }

    case Types.NEW_ELECTION:
      return { ...state, elections: state.elections.concat(action.payload) }

    case Types.SET_ELECTION_DATA:
      return {
        ...state,
        elections: state.elections.map((election) => {
          return election.id === action.payload.id ? action.payload : election
        })
      }

    case Types.GET_ELECTION_FOR_STAT:
      return { ...state, electionDetailForStat: action.payload }

    case Types.DELETE_ELECTION:
      return { ...state, elections: state.elections.filter((election) => election.id !== action.payload) }

    case Types.GET_PORTFOLIOS:
      return {
        ...state,
        electionPortFolios: action.payload[0],
        otherPortFolios: action.payload[1],
      }

    case Types.ADD_PORTFOLIOS:
      return {
        ...state,
        electionPortFolios: state.electionPortFolios.concat(action.payload),
        otherPortFolios: state.otherPortFolios.filter((other) => !action.payload.map(item => item.portfolioId).includes(other.id))
      }

    case Types.REMOVE_PORTFOLIO:
      return {
        ...state,
        electionPortFolios: state.electionPortFolios.filter((folio) => folio.portfolioId !== action.payload.id),
        otherPortFolios: state.otherPortFolios.concat(action.payload)
      }

    default:
      return state
  }
}
