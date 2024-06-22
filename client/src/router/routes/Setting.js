import { lazy } from 'react'

const SettingRoutes = [
  {
    path: '/setting/global-setting',
    exact: true,
    appLayout: true,
    className: 'email-application',
    component: lazy(() => import('../../views/globalsetting'))
  },
  {
    path: '/setting/sip-setting',
    exact: true,
    appLayout: true,
    className: 'email-application',
    component: lazy(() => import('../../views/sipsetting'))
  }
]

export default SettingRoutes
