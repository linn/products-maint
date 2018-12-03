import React from 'react';
import { storiesOf } from '@storybook/react';
import { action } from '@storybook/addon-actions';

import  SaveCancelButtons  from './SaveCancelButtons';



storiesOf('SaveCancelButtons', module)
  .add('default', () => <SaveCancelButtons />);