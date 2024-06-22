// ** Routes Imports
import AppRoutes from './Apps'
import DashboardRoutes from './Dashboards'

import SettingRoutes from './Setting'


// ** Document title
const TemplateTitle = '%s - Vuexy React Admin Template'

// ** Default Route
const DefaultRoute = '/dashboard'

// ** Merge Routes
const Routes = [
  ...DashboardRoutes,
  ...AppRoutes,
  ...SettingRoutes
]

export { DefaultRoute, TemplateTitle, Routes }
