// ** Redux Imports
import { combineReducers } from 'redux'

// ** Reducers Imports
import auth from './auth'
import navbar from './navbar'
import layout from './layout'
import chat from '@src/views/apps/chat/store/reducer'
import todo from '@src/views/apps/todo/store/reducer'
import users from '@src/views/apps/user/store/reducer'
import email from '@src/views/apps/email/store/reducer'
import invoice from '@src/views/apps/invoice/store/reducer'
import calendar from '@src/views/apps/calendar/store/reducer'
import ecommerce from '@src/views/apps/ecommerce/store/reducer'
import dataTables from '@src/views/tables/data-tables/store/reducer'
import RequierdDataStore from '../../views/globalsetting/store/reducer'
import GlobalSettingStore from '../../views/globalsetting/store/reducer/RecordReducer'
import HandleError from '../../views/Error/reducer/ErrorReducer'
import DataTablesReducer from '../../views/tables/data-tables/store/reducer'
import SIPSettingStore from '../../views/sipsetting/store/reducer'
import ExtStore from '../../views/extenison/reducer'
import ConfigFileStore from '../../views/ConfigFileApplayChanges/reducer'
import TrunkStore from '../../views/trunk/reducer'
import VoicePromptsStore from '../../views/voicePrompts/reducer'

const rootReducer = combineReducers({
  auth,
  todo,
  chat,
  email,
  users,
  navbar,
  layout,
  invoice,
  calendar,
  ecommerce,
  DataTablesReducer,
  RequierdDataStore,
  GlobalSettingStore,
  SIPSettingStore,
  ExtStore,
  TrunkStore,
  ConfigFileStore,
  VoicePromptsStore,
  HandleError
})

export default rootReducer
