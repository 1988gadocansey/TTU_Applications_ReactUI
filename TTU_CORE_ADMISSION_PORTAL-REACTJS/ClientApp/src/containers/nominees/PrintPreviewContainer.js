import { connect } from 'react-redux'
import Index from '../../components/nominees/form/print-preview'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

export default connect(mapStateToProps)(Index)
