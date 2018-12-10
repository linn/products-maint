import React from 'react';
import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';

import  SaveCancelButtons  from './SaveCancelButtons';

export const actions = {
  saveClick: action('Saved'),
  cancelClick: action('Cancelled'),
};


storiesOf('SaveCancelButtons', module)
  .addDecorator(story => <div style={{ position: "absolute", right: '45%', padding: '3rem'  }}>{story()}</div>)
  .add('default', () => <SaveCancelButtons {...actions} />);