import { connect } from 'react-redux'
import AllVoters from '../../components/voters/all-voters'
import { getAllVoters, setVoterData } from '../../actions/voters/VoterAction'
import { getAllElections } from '../../actions/elections/ElectionAction'
import { getAllGroups } from '../../actions/group/GroupAction'

const mapStateToProps = (state) => ({
  voters: state.voterReducer.voters,
  elections: state.electionReducer.elections,
  groups: state.groupReducer.groups
})

const mapDispatchToProps = (dispatch) => ({
  getAllVoters: () => dispatch(getAllVoters()),
  setVoterData: (payload) => dispatch(setVoterData(payload)),
  getAllElections: () => dispatch(getAllElections()),
  getAllGroups: () => dispatch(getAllGroups())
})

export default connect(mapStateToProps, mapDispatchToProps)(AllVoters)
