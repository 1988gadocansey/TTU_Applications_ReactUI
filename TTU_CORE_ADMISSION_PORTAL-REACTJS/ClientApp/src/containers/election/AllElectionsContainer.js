import { connect } from 'react-redux'
import { deleteElection, getAllElections } from '../../actions/elections/ElectionAction'
import AllElections from '../../components/elections/all-elections'

const mapStateToProps = (state) => ({
  elections: state.electionReducer.elections
})

const mapDispatchToProps = (dispatch) => ({
  getAllElections: (payload) => dispatch(getAllElections(payload)),
  deleteElection: (payload) => dispatch(deleteElection(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(AllElections)
