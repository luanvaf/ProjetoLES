import React from 'react';
import { useAuth } from '../contexts/auth';

import SignRoutes from './signRoutes';
import OtherRoutes from './otherRoutes';

const Routes: React.FC = () => {
    const { signed } = useAuth();

    return signed ? <OtherRoutes /> : <SignRoutes />;
};

export default Routes;