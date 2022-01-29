import { connect } from 'react-redux'
import Group from '../../components/groups'
import { getAllGroups, setGroupData } from '../../actions/group/GroupAction'

const mapStateToProps = (state) => ({
  groups: state.groupReducer.groups,
  success: state.groupReducer.success,
})

const mapDispatchToProps = (dispatch) => ({
  getAllGroups: () => getAllGroups(),
  setGroupData: (payload) => dispatch(setGroupData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Group)
