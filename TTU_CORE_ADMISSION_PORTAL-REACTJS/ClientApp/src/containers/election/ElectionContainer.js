import { connect } from 'react-redux'
import Election from '../../components/elections'
import { getAllElections, setElectionData } from '../../actions/elections/ElectionAction'

const mapStateToProps = (state) => ({
  elections: state.electionReducer.elections
})

const mapDispatchToProps = (dispatch) => ({
  getAllElections: (payload) => dispatch(getAllElections(payload)),
  setElectionData: (payload) => dispatch(setElectionData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Election)
