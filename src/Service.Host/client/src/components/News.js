import React, { useState, useEffect, useRef } from 'react';
import { Snackbar, withStyles } from '@material-ui/core';
import Slide from '@material-ui/core/Slide';
import CloseIcon from '@material-ui/icons/Close';

const styles = theme => ({
    root: {
        background: theme.palette.primary.dark
    },
    message: {
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        marginRight: '120px'
    },
    icon: {
        fontSize: 20,
        opacity: 0.9,
        float: 'right',
        position: 'fixed',
        right: '12px'
    }
});

function useInterval(callback, delay) {
    const savedCallback = useRef();
    useEffect(() => {
        savedCallback.current = callback;
    }, [callback]);

    useEffect(() => {
        const tick = () => {
            savedCallback.current();
        };
        if (delay !== null) {
            const id = setInterval(tick, delay);
            return () => clearInterval(id);
        }
        return null;
    }, [delay]);
}

function SlideTransition(props) {
    return <Slide {...props} direction="left" />;
}

function Notifications({ news, classes }) {
    const [count, setCount] = useState(0);
    const [open, setOpen] = useState(true);

    useInterval(() => {
        if (count < news.notifications.length - 1) {
            setCount(count + 1);
        } else {
            setCount(0);
        }
    }, 8000);

    const handleClose = () => setOpen(false);

    return news.notifications.map((e, i) => (
        <Snackbar
            message={
                <span id="client-snackbar" className={classes.message}>
                    {`${e.title} ${e.content}`}
                    <CloseIcon className={classes.icon} onClick={handleClose} />
                </span>
            }
            anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
            open={count === i && open}
            TransitionComponent={SlideTransition}
            ContentProps={{
                classes: {
                    root: classes.root
                }
            }}
        />
    ));
}

export default withStyles(styles)(Notifications);
