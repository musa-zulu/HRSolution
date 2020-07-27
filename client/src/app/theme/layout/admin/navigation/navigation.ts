import {Injectable} from '@angular/core';

export interface NavigationItem {
  id: string;
  title: string;
  type: 'item' | 'collapse' | 'group';
  translate?: string;
  icon?: string;
  hidden?: boolean;
  url?: string;
  classes?: string;
  exactMatch?: boolean;
  external?: boolean;
  target?: boolean;
  breadcrumbs?: boolean;
  function?: any;
  badge?: {
    title?: string;
    type?: string;
  };
  children?: Navigation[];
}

export interface Navigation extends NavigationItem {
  children?: NavigationItem[];
}

const NavigationItems = [
  {
    id: 'navigation',
    title: 'Navigation',
    type: 'group',
    icon: 'feather icon-monitor',
    children: [
      {
        id: 'dashboard',
        title: 'Dashboard',
        type: 'item',
        url: '/dashboard/default',
        classes: 'nav-item',
        icon: 'feather icon-home'
      },
      {
        id: 'leave',
        title: 'Leave',
        type: 'collapse',
        icon: 'fa fa-suitcase',
        children: [
          {
            id: 'application',
            title: 'Application',
            type: 'item',
            url: '/layout/static',
            target: true
          },
          {
            id: 'calendar',
            title: 'Calendar',
            type: 'item',
            url: '/layout/horizontal',
            target: true
          }
        ]
      }
    ]
  },
  {
    id: 'settings',
    title: 'SETTINGS',
    type: 'group',
    icon: 'fa fa-cog',
    children: [
      {
        id: 'bioinfo',
        title: 'Bio Info',
        type: 'collapse',
        icon: 'fa fa-cog',      
        children: [
          {
            id: 'usersettings',
            title: 'User Settings',
            type: 'item',
            url: '/layout/static',
            target: true
          }] 
      }
    ]
  },
  {
    id: 'pages',
    title: 'Pages',
    type: 'group',
    icon: 'feather icon-file-text',
    children: [
      {
        id: 'auth',
        title: 'Authentication',
        type: 'collapse',
        icon: 'feather icon-lock',
        children: [
          {
            id: 'signup',
            title: 'Sign up',
            type: 'item',
            url: '/auth/signup',
            target: true,
            breadcrumbs: false
          },
          {
            id: 'signin',
            title: 'Sign in',
            type: 'item',
            url: '/auth/signin',
            target: true,
            breadcrumbs: false
          }
        ]
      },
    ]
  }
];

@Injectable()
export class NavigationItem {
  public get() {
    return NavigationItems;
  }
}
